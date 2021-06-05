import React from 'react';
import { Link, useHistory } from 'react-router-dom';
import { FiLock, FiLogIn } from 'react-icons/fi';
import { Navbar, Nav, Form, FormControl, Button, InputGroup} from 'react-bootstrap';

import './styles.css';

const NavBar = () => {
    return (
        <Navbar bg="light" expand="lg">
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="mr-auto">
            <Nav.Link href="#home">Home</Nav.Link>
            <Nav.Link href="#link">Produtos</Nav.Link>
            <Nav.Link href="#link">Lançamentos</Nav.Link>
            <Nav.Link href="#link">Usuários</Nav.Link>
          </Nav>
          <Form inline>
            <InputGroup className="mr-2">
            <InputGroup.Prepend>
                <InputGroup.Text id="basic-addon1">@</InputGroup.Text>
            </InputGroup.Prepend>
            <FormControl placeholder="Usuário" naria-label="Usuário" aria-describedby="basic-addon1"/>
            </InputGroup>
            <InputGroup className="mr-2">
            <InputGroup.Prepend>
                <InputGroup.Text id="basic-addon1"><FiLock /></InputGroup.Text>
            </InputGroup.Prepend>
            <FormControl placeholder="Senha" aria-label="Senha" aria-describedby="basic-addon1" />
            </InputGroup>
            <Button variant="outline-primary"><FiLogIn /></Button>
        </Form>
        </Navbar.Collapse>
      </Navbar>
    );
  }

  export default NavBar;