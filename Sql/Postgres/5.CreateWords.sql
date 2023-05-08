CREATE TABLE IF NOT EXISTS public."Words"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Original" character(100) COLLATE pg_catalog."default" NOT NULL,
    "Translation" character(100) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Words_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Words"
    OWNER to postgres;