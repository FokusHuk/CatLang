CREATE TABLE IF NOT EXISTS public."SetWords"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "WordId" integer NOT NULL,
    "SetId" uuid NOT NULL,
    CONSTRAINT "SetWords_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_SetWords_Sets" FOREIGN KEY ("SetId")
        REFERENCES public."Sets" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "FK_SetWords_Words" FOREIGN KEY ("WordId")
        REFERENCES public."Words" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."SetWords"
    OWNER to postgres;