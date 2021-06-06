import React, { useState, useEffect, ChangeEvent } from 'react';
import { Link } from 'react-router-dom';

import NavBar from '../../components/navBar';
import Cards from '../../components/cards';

import './styles.css';

const Home = () => {
    return (
        <>
        <NavBar />
            <div className="cardsArea">
                <Cards Header="Produtos" background="primary" linkName1="Novo produto" linkClass1="btn btn-outline-primary" linkName2="Listar produtos" linkAction1="/" linkAction2="/products" idx="Produto" />
                <Cards Header="Categorias" background="warning" linkName1="Nova categoria" linkClass1="btn btn-outline-warning" linkName2="Listar categorias" linkAction1="/" linkAction2="/categories" idx="Categorias" />
                <Cards Header="Unidade de medida" background="danger" linkName1="Nova unidade" linkClass1="btn btn-outline-danger" linkName2="Listar unidades" linkAction1="/" linkAction2="/measures" idx="Unidades de medida" />
                <Cards Header="Usuários" background="secondary" linkName1="Novo usuário" linkClass1="btn btn-outline-success" linkAction1="/newUser" linkName2="Listar usuários"  linkAction2="/users" idx="Usuario" />
                <Cards Header="Lançamentos" background="success" linkName1="Novo lançamento" linkClass1="btn btn-outline-info" linkName2="Listar lançamentos" linkAction1="/" linkAction2="/" idx="Lancamentos" />
            </div>
        </>
    );
}

export default Home;