import React, { ChangeEvent, FormEvent, useState } from 'react';
import { Alert, Button, Container, Form, FormControl, InputGroup, Row } from 'react-bootstrap';
import { FiLock } from 'react-icons/fi';
import { Link, useHistory } from 'react-router-dom';
import api from '../../../services/api';

import './styles.css';

interface Measures {
    code: string,
    name: string,
    initials: string,
}

interface ErroMsg {
    msg: string,
}

const NewMeasures = ({}) => {
    const history = useHistory();
    
    const [erroMsg, setErroMsg] = useState<ErroMsg>();

    const [formData, setFormData] = useState({
        code: '',
        name: '',
        initials: '',
    });
    
    const [measures, setMeasures] = useState<Measures[]>([]);

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const {name, value} = event.target;
        setFormData({...formData, [name]: value});
    }
    
    async function handleSubmit(event: FormEvent) {
        event.preventDefault();

        const {code, name, initials} = formData;

        const data = {
            code: code.toUpperCase(),
            name: name,
            initials: initials,
        }

        await api.post('user', data).then((response) => {
            setMeasures(response.data);
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
                        <h4 className="mb-5">Nova unidade de medida</h4>
                        <FormControl onChange={handleInputChange} className="mb-2" id="code" name="code" type="text" placeholder="Código (ABC0000)" naria-label="code" />
                        <FormControl onChange={handleInputChange} className="mb-2" id="name" name="name" type="text" placeholder="Usuário" naria-label="name" />
                        <FormControl onChange={handleInputChange} className="mb-2" id="name" name="name" type="text" placeholder="Usuário" naria-label="name" />
                        <div id="buttons">
                            <Button className="ml-4" variant="outline-success" type="submit">Salvar</Button>
                            <Link to="" onClick={handleClick} className="btn btn-outline-danger ml-4">Cancelar</Link>
                        </div>
                        <Alert className="text-danger">{erroMsg}</Alert>
                    </Form>
                </Row>  
            </Container>
        </main>      
    );
}

export default NewMeasures;
