--
-- PostgreSQL database dump
--

\restrict wsaFhl5ItCT0DCbEWP7od9psft3mbMtztRu1nj0ffcAOVTMO8OB8t6KOakv8rZ1

-- Dumped from database version 17.11 (Debian 17.11-1.pgdg13+2)
-- Dumped by pg_dump version 17.11 (Debian 17.11-1.pgdg13+2)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: lessons; Type: TABLE; Schema: public; Owner: appuser
--

CREATE TABLE public.lessons (
    id integer NOT NULL,
    title character varying(100) NOT NULL
);


ALTER TABLE public.lessons OWNER TO appuser;

--
-- Name: lessons_id_seq; Type: SEQUENCE; Schema: public; Owner: appuser
--

CREATE SEQUENCE public.lessons_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.lessons_id_seq OWNER TO appuser;

--
-- Name: lessons_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: appuser
--

ALTER SEQUENCE public.lessons_id_seq OWNED BY public.lessons.id;


--
-- Name: lessons id; Type: DEFAULT; Schema: public; Owner: appuser
--

ALTER TABLE ONLY public.lessons ALTER COLUMN id SET DEFAULT nextval('public.lessons_id_seq'::regclass);


--
-- Data for Name: lessons; Type: TABLE DATA; Schema: public; Owner: appuser
--

COPY public.lessons (id, title) FROM stdin;
1	Docker volumes en PostgresSQL
\.


--
-- Name: lessons_id_seq; Type: SEQUENCE SET; Schema: public; Owner: appuser
--

SELECT pg_catalog.setval('public.lessons_id_seq', 1, true);


--
-- Name: lessons lessons_pkey; Type: CONSTRAINT; Schema: public; Owner: appuser
--

ALTER TABLE ONLY public.lessons
    ADD CONSTRAINT lessons_pkey PRIMARY KEY (id);


--
-- PostgreSQL database dump complete
--

\unrestrict wsaFhl5ItCT0DCbEWP7od9psft3mbMtztRu1nj0ffcAOVTMO8OB8t6KOakv8rZ1

