import React from 'react';
import { Navbar, Nav} from 'react-bootstrap';

import './styles.css';

const NavBar = () => {    
    return (
        <Navbar bg="light" fixed="top" expand="lg" className="mb-5">
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="mr-auto">
            <Nav.Link href="/home">Home</Nav.Link>
            <Nav.Link href="/products">Produtos</Nav.Link>
            <Nav.Link href="/users">Usuários</Nav.Link>
            <Nav.Link href="/movements">Lançamentos</Nav.Link>
            <Nav.Link href="/">Sair</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }

  export default NavBar;