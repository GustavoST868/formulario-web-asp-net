PGDMP  "    4                 }         
   Formulario    17.2    17.2     "           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            #           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            $           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            %           1262    16384 
   Formulario    DATABASE        CREATE DATABASE "Formulario" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Portuguese_Brazil.1252';
    DROP DATABASE "Formulario";
                     postgres    false            Ϊ            1259    16386    pessoa    TABLE       CREATE TABLE public.pessoa (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    cpf character varying(11) NOT NULL,
    rg character varying(20) NOT NULL,
    e_mail character varying(255) NOT NULL,
    date_birth date NOT NULL,
    gender character varying(50) NOT NULL,
    nationality character varying(100) NOT NULL,
    marital_status character varying(50) NOT NULL
);
    DROP TABLE public.pessoa;
       public         heap r       postgres    false            Ω            1259    16385    pessoa_id_seq    SEQUENCE        CREATE SEQUENCE public.pessoa_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 $   DROP SEQUENCE public.pessoa_id_seq;
       public               postgres    false    218            &           0    0    pessoa_id_seq    SEQUENCE OWNED BY     ?   ALTER SEQUENCE public.pessoa_id_seq OWNED BY public.pessoa.id;
          public               postgres    false    217                       2604    16389 	   pessoa id    DEFAULT     f   ALTER TABLE ONLY public.pessoa ALTER COLUMN id SET DEFAULT nextval('public.pessoa_id_seq'::regclass);
 8   ALTER TABLE public.pessoa ALTER COLUMN id DROP DEFAULT;
       public               postgres    false    218    217    218                      0    16386    pessoa 
   TABLE DATA           l   COPY public.pessoa (id, name, cpf, rg, e_mail, date_birth, gender, nationality, marital_status) FROM stdin;
    public               postgres    false    218   B       '           0    0    pessoa_id_seq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.pessoa_id_seq', 9, true);
          public               postgres    false    217                       2606    16395    pessoa pessoa_cpf_key 
   CONSTRAINT     O   ALTER TABLE ONLY public.pessoa
    ADD CONSTRAINT pessoa_cpf_key UNIQUE (cpf);
 ?   ALTER TABLE ONLY public.pessoa DROP CONSTRAINT pessoa_cpf_key;
       public                 postgres    false    218                       2606    16397    pessoa pessoa_e_mail_key 
   CONSTRAINT     U   ALTER TABLE ONLY public.pessoa
    ADD CONSTRAINT pessoa_e_mail_key UNIQUE (e_mail);
 B   ALTER TABLE ONLY public.pessoa DROP CONSTRAINT pessoa_e_mail_key;
       public                 postgres    false    218                       2606    16393    pessoa pessoa_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.pessoa
    ADD CONSTRAINT pessoa_pkey PRIMARY KEY (id);
 <   ALTER TABLE ONLY public.pessoa DROP CONSTRAINT pessoa_pkey;
       public                 postgres    false    218                  xΡγββ Ε ©     