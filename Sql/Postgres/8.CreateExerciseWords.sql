CREATE TABLE IF NOT EXISTS public."ExerciseWords"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "ExerciseId" uuid NOT NULL,
    "SetId" uuid NOT NULL,
    "WordId" integer NOT NULL,
    "Answer" text COLLATE pg_catalog."default" NOT NULL,
    "Date" date NOT NULL,
    "IsCorrect" boolean NOT NULL,
    CONSTRAINT "ExerciseWords_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ExerciseWords_Sets" FOREIGN KEY ("SetId")
        REFERENCES public."Sets" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_ExerciseWords_Words" FOREIGN KEY ("WordId")
        REFERENCES public."Words" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."ExerciseWords"
    OWNER to postgres;