CREATE TABLE IF NOT EXISTS public."Sets"
(
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "AverageStudyTime" real NOT NULL,
    "StudyTopic" character(100) COLLATE pg_catalog."default" NOT NULL,
    "Popularity" integer NOT NULL,
    "Efficiency" real NOT NULL,
    "Complexity" real NOT NULL,
    CONSTRAINT "Sets_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Sets_Users" FOREIGN KEY ("UserId")
        REFERENCES public."Users" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Sets"
    OWNER to postgres;
