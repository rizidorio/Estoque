import React from 'react';

import NavBar from '../../components/navBar';
import Cards from '../../components/cards';

import './styles.css';

const Home = () => {
    return (
        <>
        <NavBar />
            <div className="cardsArea">
                <Cards Header="Produtos" background="primary" linkName1="Novo produto" linkClass1="btn btn-outline-primary" linkName2="Listar produtos" linkAction1="/newProduct" linkAction2="/products" idx="Produto" />
                <Cards Header="Usuários" background="secondary" linkName1="Novo usuário" linkClass1="btn btn-outline-success" linkAction1="/newUser" linkName2="Listar usuários"  linkAction2="/users" idx="Usuario" />
                <Cards Header="Lançamentos" background="success" linkName1="Novo lançamento" linkClass1="btn btn-outline-info" linkName2="Listar lançamentos" linkAction1="/newMovement" linkAction2="/movements" idx="Lancamentos" />
            </div>
        </>
    );
}

export default Home;