CREATE TABLE IF NOT EXISTS public."DatabaseMigrations"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    "Version" integer NOT NULL,
    "Date" date NOT NULL,
    CONSTRAINT "DatabaseMigrations_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."DatabaseMigrations"
    OWNER to postgres;