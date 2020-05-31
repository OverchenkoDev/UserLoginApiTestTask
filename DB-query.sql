--
-- PostgreSQL database dump
--

-- Dumped from database version 12.1
-- Dumped by pg_dump version 12.1

-- Started on 2020-06-01 00:37:02

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 2834 (class 1262 OID 16393)
-- Name: UsersTestDB; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "UsersTestDB" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';


ALTER DATABASE "UsersTestDB" OWNER TO postgres;

\connect "UsersTestDB"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
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
-- TOC entry 203 (class 1259 OID 16399)
-- Name: UserNotes; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserNotes" (
    "Id" integer NOT NULL,
    "Name" character varying(15),
    "BirthDate" date,
    "Amount" double precision
);


ALTER TABLE public."UserNotes" OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 16409)
-- Name: UserNotes_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."UserNotes" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."UserNotes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 202 (class 1259 OID 16394)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" integer NOT NULL,
    "Username" character varying(15) NOT NULL,
    "Password" character varying(16) NOT NULL,
    "Mail" character varying(40) NOT NULL,
    "Activated" boolean DEFAULT false NOT NULL,
    "UserData" integer
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 16411)
-- Name: Users_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."Users" ALTER COLUMN "Id" ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Users_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 2826 (class 0 OID 16399)
-- Dependencies: 203
-- Data for Name: UserNotes; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."UserNotes" OVERRIDING SYSTEM VALUE VALUES (1, 'Yaroslaw', '1996-01-23', 100.54);
INSERT INTO public."UserNotes" OVERRIDING SYSTEM VALUE VALUES (3, 'Aleksey', NULL, 248);
INSERT INTO public."UserNotes" OVERRIDING SYSTEM VALUE VALUES (4, 'Ivan', NULL, NULL);
INSERT INTO public."UserNotes" OVERRIDING SYSTEM VALUE VALUES (2, NULL, NULL, 400);


--
-- TOC entry 2825 (class 0 OID 16394)
-- Dependencies: 202
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Users" OVERRIDING SYSTEM VALUE VALUES (1, 'Atrocus', 'my_pass_12!', 'yarikoverchenko@gmail.com', true, 1);
INSERT INTO public."Users" OVERRIDING SYSTEM VALUE VALUES (2, 'Lesha', 'qwerty123!', 'aleksey.nv@yandex.ru', true, 3);
INSERT INTO public."Users" OVERRIDING SYSTEM VALUE VALUES (3, 'Vanish', 'i_am_ivan1', 'ivan404@gmail.com', false, 4);
INSERT INTO public."Users" OVERRIDING SYSTEM VALUE VALUES (4, 'Annet', 'gerbutova321!', 'anya.gerb@gmail.com', false, 2);


--
-- TOC entry 2835 (class 0 OID 0)
-- Dependencies: 204
-- Name: UserNotes_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."UserNotes_Id_seq"', 4, true);


--
-- TOC entry 2836 (class 0 OID 0)
-- Dependencies: 205
-- Name: Users_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Users_Id_seq"', 4, true);


--
-- TOC entry 2697 (class 2606 OID 16403)
-- Name: UserNotes UserNotes_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserNotes"
    ADD CONSTRAINT "UserNotes_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2695 (class 2606 OID 16398)
-- Name: Users Users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2698 (class 2606 OID 16404)
-- Name: Users user_note_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT user_note_fk FOREIGN KEY ("Id") REFERENCES public."UserNotes"("Id") ON DELETE SET NULL NOT VALID;


-- Completed on 2020-06-01 00:37:03

--
-- PostgreSQL database dump complete
--

