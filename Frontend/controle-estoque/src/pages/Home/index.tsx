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
                <Cards Header="Produtos" background="primary" buttonBg="info" buttonName1="Novo produto" buttonName2="Listar produtos" idx="Produto" />
                <Cards Header="Usuários" background="secondary" buttonBg="danger" buttonName1="Novo usuário" buttonName2="Listar usuários" idx="Usuario" />
                <Cards Header="Lançamentos" background="success" buttonBg="warning" buttonName1="Nova entrada" buttonName2="Nova saída" idx="Usuario" />
            </div>
        </>
    );
}

export default Home;