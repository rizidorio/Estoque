import React, { useState, ChangeEvent, FormEvent } from 'react';
import { useHistory, Link } from 'react-router-dom';
import { Form, Button, Alert, Container, Row, InputGroup, FormControl } from 'react-bootstrap';

import api from '../../services/api';
import './styles.css';
import { FiLock, FiLogIn } from 'react-icons/fi';

interface UserLogin {
    key: string,
}

interface ErroMsg {
    msg: string,
}

const Login = ({}) => {
    const history = useHistory();
    const [formData, setFormData] = useState({
        name: '',
        password: '',
    });
    const [userLogin, setUserLogin] = useState<UserLogin>();
    const [erroMsg, setErroMsg] = useState<ErroMsg>();

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const {name, value} = event.target;

        setFormData({...formData, [name]: value});
    }

    async function handleSubmit(event: FormEvent) {
        event.preventDefault();

        const {name, password} = formData;

        const data = {
            name: name,
            password: password,
        }

        await api.post('user/login', data).then((response) => {
            setUserLogin(response.data.token);
            sessionStorage.setItem('login', response.data.token);
            history.push('/home');
        }).catch((error) => {
            if (error.response) {
                setErroMsg(error.response.data);
            }
        });
    }

    return (
        <main>
            <Container>
                <Row className="align-items-center">
                    <Form onSubmit={handleSubmit}>
                        <h4 className="mb-5">Faça seu login</h4>
                        <InputGroup className="mb-2">
                        <InputGroup.Prepend>
                            <InputGroup.Text id="basic-addon1">@</InputGroup.Text>
                        </InputGroup.Prepend>
                        <FormControl id="name" name="name" type="text" onChange={handleInputChange} placeholder="Usuário" naria-label="name" aria-describedby="basic-addon1"/>
                        </InputGroup>
                        <InputGroup className="mb-2">
                        <InputGroup.Prepend>
                            <InputGroup.Text id="basic-addon1"><FiLock /></InputGroup.Text>
                        </InputGroup.Prepend>
                        <FormControl id="password" name="password" onChange={handleInputChange} type="password" placeholder="Senha" aria-label="password" aria-describedby="basic-addon1" />
                        </InputGroup>
                        <div id="buttons">
                            <Button className="ml-4" variant="outline-success" type="submit"><FiLogIn /> Entrar</Button>
                            <Link to="/newUser" className="btn btn-outline-primary ml-4"><FiLogIn /> Novo</Link>
                        </div>
                        <Alert className="text-danger">{erroMsg}</Alert>
                    </Form>
                </Row>  
            </Container>
        </main>      
    );
}

export default Login;