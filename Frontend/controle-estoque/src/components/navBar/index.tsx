import React from 'react';
import { Link, useHistory } from 'react-router-dom';
import { FiLock, FiLogIn } from 'react-icons/fi';
import { Navbar, Nav, Form, FormControl, Button, InputGroup} from 'react-bootstrap';

import './styles.css';

const NavBar = () => {
    return (
        <Navbar bg="light" fixed="top" expand="lg" className="mb-5">
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="mr-auto">
            <Nav.Link href="#home">Home</Nav.Link>
            <Nav.Link href="#link">Produtos</Nav.Link>
            <Nav.Link href="#link">Lançamentos</Nav.Link>
            <Nav.Link href="#link">Usuários</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    );
  }

  export default NavBar;