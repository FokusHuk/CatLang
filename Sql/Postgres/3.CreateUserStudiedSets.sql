CREATE TABLE IF NOT EXISTS public."UserStudiedSets"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "SetId" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "AttemptsCount" integer NOT NULL,
    "IsStudied" boolean NOT NULL,
    "CorrectAnswers" integer NOT NULL,
    "AnswersCount" integer NOT NULL,
    CONSTRAINT "UserStudiedSets_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_UserStudiedSets_Sets" FOREIGN KEY ("SetId")
        REFERENCES public."Sets" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_UserStudiedSets_Users" FOREIGN KEY ("UserId")
        REFERENCES public."Users" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."UserStudiedSets"
    OWNER to postgres;
