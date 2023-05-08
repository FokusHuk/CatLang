CREATE TABLE IF NOT EXISTS public."StudiedWords"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "UserId" uuid NOT NULL,
    "WordId" integer NOT NULL,
    "CorrectAnswers" integer NOT NULL,
    "IncorrectAnswers" integer NOT NULL,
    "LastAppearanceDate" date NOT NULL,
    "Status" smallint NOT NULL,
    "RiskFactor" real NOT NULL,
    CONSTRAINT "StudiedWords_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_StudiedWords_Users" FOREIGN KEY ("UserId")
        REFERENCES public."Users" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_StudiedWords_Words" FOREIGN KEY ("WordId")
        REFERENCES public."Words" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."StudiedWords"
    OWNER to postgres;
