--5.1 Novy prestup 

CREATE OR ALTER PROCEDURE spNovyPrestup (
	@p_id_hrac int,
	@p_novy_klub int,
	@p_cena_prestupu int

)
AS
	DECLARE @now date
	DECLARE @stary_klub int
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			SELECT @stary_klub = id_klub FROM volejbal.hrac WHERE hrac.id_hrac = @p_id_hrac
			IF @stary_klub IS NULL
					THROW 51000,'Nelze pøestup provést. Hráè není èlenem žádného klubu.', 1; 
			SELECT @now = CURRENT_TIMESTAMP
			UPDATE volejbal.hrac SET id_klub = @p_novy_klub WHERE id_hrac = @p_id_hrac
			INSERT INTO volejbal.historie_prestupu (id_hrac, stary_klub, novy_klub, datum_prestupu, cena_prestupu) VALUES (@p_id_hrac, @stary_klub, @p_novy_klub,@now,@p_cena_prestupu)
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			PRINT 'Pøestup hráèe byl neúspìšný!';
			ROLLBACK TRANSACTION
		END CATCH
END
GO



--5.1 Odehrani zapasu
CREATE OR ALTER PROCEDURE spOdehraniZapasu (
	@p_id_zapasu int,
	@p_id_domaci int,
	@p_id_hoste int,
	@p_kolo int,
	@p_domaci_sety int,
	@p_hoste_sety int,
	@p_id_rozhodci int,
	@p_pocet_divaku int
)
AS
	DECLARE @body_dom int
	DECLARE @body_hoste int
	DECLARE @vyhra_dom int
	DECLARE @prohra_dom int
	DECLARE @vyhra_hoste int
	DECLARE @prohra_hoste int
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			UPDATE volejbal.zapas SET domaci_sety = @p_domaci_sety, hoste_sety = @p_hoste_sety, pocet_divaku = @p_pocet_divaku WHERE id_zapas = @p_id_zapasu
			UPDATE volejbal.rozhodci SET pocet_zapasu = pocet_zapasu+1 WHERE id_rozhodci = @p_id_rozhodci
			IF (@p_domaci_sety = 3 AND @p_hoste_sety = 2)
				BEGIN
					SELECT @body_dom = 2,
							@vyhra_dom = 1,
							@prohra_dom = 0,
							@body_hoste = 1,
							@vyhra_hoste = 0,
							@prohra_hoste = 1;
				END
			ELSE IF (@p_domaci_sety = 2 AND @p_hoste_sety = 3)
				BEGIN
					SELECT @body_dom = 1,
							@vyhra_dom = 0,
							@prohra_dom = 1,
							@body_hoste = 2,
							@vyhra_hoste = 1,
							@prohra_hoste = 0;
				END
			ELSE IF (@p_domaci_sety = 3 AND @p_hoste_sety <= 1)
				BEGIN
					SELECT @body_dom = 3,
							@vyhra_dom = 1,
							@prohra_dom = 0,
							@body_hoste = 0,
							@vyhra_hoste = 0,
							@prohra_hoste = 1;
				END
			ELSE IF (@p_domaci_sety <= 1 AND @p_hoste_sety = 3)
				BEGIN
					SELECT @body_dom = 0,
							@vyhra_dom = 0,
							@prohra_dom = 1,
							@body_hoste = 3,
							@vyhra_hoste = 1,
							@prohra_hoste = 0;
				END
			UPDATE volejbal.tabulka SET zapasy_celkem = zapasy_celkem+1, vyhry=vyhry+@vyhra_dom, prohry=prohry+@prohra_dom, vyhrane_sety=vyhrane_sety+@p_domaci_sety, prohrane_sety=prohrane_sety+@p_hoste_sety, body=body+@body_dom WHERE id_klub = @p_id_domaci
			UPDATE volejbal.tabulka SET zapasy_celkem = zapasy_celkem+1, vyhry=vyhry+@vyhra_hoste, prohry=prohry+@prohra_hoste, vyhrane_sety=vyhrane_sety+@p_hoste_sety, prohrane_sety=prohrane_sety+@p_domaci_sety, body=body+@body_hoste WHERE id_klub = @p_id_hoste
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			PRINT 'Odehrání zápasu bylo neúspìšné!';
			ROLLBACK TRANSACTION
		END CATCH
END
GO


--8.8 Zmena rozhodciho v zapase
CREATE TRIGGER trZmenaRozhodciho
  ON volejbal.zapas
  AFTER UPDATE AS BEGIN
    DECLARE @id_stary_rozhodci int;
    DECLARE @id_novy_rozhodci int;

	IF UPDATE(id_rozhodci)
		BEGIN
			SELECT @id_stary_rozhodci = id_rozhodci from DELETED;
			SELECT @id_novy_rozhodci = id_rozhodci from INSERTED;
			UPDATE volejbal.rozhodci SET pocet_zapasu = pocet_zapasu -1 WHERE id_rozhodci = @id_stary_rozhodci
			UPDATE volejbal.rozhodci SET pocet_zapasu = pocet_zapasu +1 WHERE id_rozhodci = @id_novy_rozhodci
		END
END