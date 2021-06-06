import React, { ChangeEvent, FormEvent, useEffect, useState } from 'react';
import { Alert, Button, Container, Form, FormControl, Row } from 'react-bootstrap';
import { Link, useHistory } from 'react-router-dom';
import api from '../../../services/api';

import './styles.css';

interface User {
    name: string,
    code: string,
    password: string,
    role: string,
}

interface ErroMsg {
    msg: string,
}

const EditUser = () => {
    const history = useHistory();
    
    const [erroMsg, setErroMsg] = useState<ErroMsg>();
    const [user, setUser] = useState<User>({
        name: '',
        code: '',
        password: '',
        role: '',
    });

    const token = sessionStorage.getItem('login');
    const userCode = localStorage.getItem('userCode');

    useEffect(() => {
       api.get(`user/${userCode}`, {
            headers: {
                 "Authorization" : `bearer ${token}`
                }, 
            }).then(response => {
            setUser(response.data);
            setFormData(response.data);
        }).catch((error) => {
            console.log(error.response)
        })
    }, []);

    const [formData, setFormData] = useState({
        name: '',
        code: '',
        password: '',
        role: '',
    });
    

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const {name, value} = event.target;
        setFormData({...formData, [name]: value});
    }
    
    async function handleSubmit(event: FormEvent) {
        event.preventDefault();

        const {name, code, password, role} = formData;

        const data = {
            name: name,
            code: code.toUpperCase(),
            password: password ?? user.password,
            role: role,
        }

        console.log(data)

        await api.put('user', data, {
            headers: {
                 "Authorization" : `bearer ${token}`
                }, 
            }).then((response) => {
            setUser(response.data);
            history.goBack();
        }).catch((error) => {
            if (error.response) {
                setErroMsg(error.response.data);
            }
        });        
    }

    async function handleClick() {
        history.goBack();
    }

    return (
        <main>
            <Container>
                <Row>
                    <Form onSubmit={handleSubmit}>
                        <h4 className="mb-5">Editar usuário</h4>
                        <FormControl onChange={handleInputChange} className="mb-2" id="code" name="code" type="text" placeholder={user.code ?? "Código (ABC0000)"} naria-label="code" />
                        <FormControl onChange={handleInputChange} className="mb-2" id="name" name="name"  type="text" placeholder={user.name ?? "Usuários"} naria-label="name" />
                        <FormControl onChange={handleInputChange} className="mb-2" id="password" name="password" type="password"  placeholder="Senha" naria-label="password" />
                        <FormControl onChange={handleInputChange} className="mb-2" id="role" name="role" type="text"  placeholder={user.role ?? "Pefil"} naria-label="role" />
                        <div id="buttons">
                            <Button className="ml-4" variant="outline-success" type="submit">Salvar</Button>
                            <Link to="" onClick={handleClick} className="btn btn-outline-danger ml-4"> Cancelar</Link>
                        </div>
                        <Alert className="text-danger">{erroMsg}</Alert>
                    </Form>
                </Row>  
            </Container>
        </main>      
    );
}

export default EditUser;
