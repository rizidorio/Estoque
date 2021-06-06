import React, { ChangeEvent, FormEvent, useEffect, useState } from 'react';
import { Alert, Button, Container, Form, FormControl, FormGroup, Row } from 'react-bootstrap';
import { Link, useHistory } from 'react-router-dom';
import api from '../../../services/api';
import NavBar from '../../../components/navBar';

import './styles.css';

interface Movement {
    productId: number,
    typeMovement: string,
    quantity: number,
}

interface Product {
    id: number,
    sku: string,
    name: string,
    description: string,
    category: string,
    cust: number,
}

interface ErroMsg {
    msg: string,
}

const NewMovement = ({}) => {
    const history = useHistory();
    const token = sessionStorage.getItem('login');
    
    const [erroMsg, setErroMsg] = useState<ErroMsg>();
    const [selProduct, setSelProduct] = useState<Product[]>([]);

    const [formData, setFormData] = useState({
        productId: 0,
        typeMovement: '',
        quantity: 0, 
    });
    
    const [movement, setMovement] = useState<Movement[]>([]);

    useEffect(() => {
        api.get('product', {
            headers: {
                 "Authorization" : `bearer ${token}` 
            }
        }).then(response => {
            setSelProduct(response.data);
            console.log()
        }).catch((error) => {
            console.log(error)
        });        
    }, []);

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const {name, value} = event.target;
        setFormData({...formData, [name]: value});
    }
    
    async function handleSubmit(event: FormEvent) {
        event.preventDefault();

        const {productId, typeMovement, quantity} = formData;

        const data = {
            productId: productId,
            typeMovement: typeMovement,
            quantity: quantity,
        }
        console.log(data);
        api.post('stockMovement', data, {
            headers: {
                    "Authorization" : `bearer ${token}` 
            }
        }).then((response) => {
            setMovement(response.data);
            history.goBack();
        }).catch((error) => {
            if (error.response) {
                setErroMsg(error.response.data);
                console.log(error.response);
            }
        });               
    }

    async function handleClick() {
        history.goBack();
    }

    return (
        <main>
            <Container>
            <NavBar />
                <Row>
                    <Form onSubmit={handleSubmit}>
                        <h4 className="mb-5">Novo lançamento</h4>
                        <FormGroup>
                            <FormControl onChange={handleInputChange} id="typeMovement" name="typeMovement" as="select" className="mb-2">
                                <option>Tipo lançamento</option>
                                <option value="E">Entrada</option>
                                <option value="S">Saída</option>
                            </FormControl>
                            <FormControl onChange={handleInputChange} id="productId" name="productId" as="select" className="mb-2">
                                <option value="0" hidden>Produtos</option>
                                {selProduct.map(prod => (
                                    <option key={prod.id} value={prod.id}>{prod.name}</option>
                                ))}
                            </FormControl>
                            <FormControl onChange={handleInputChange} className="mb-2" id="quantity" name="quantity" type="number" placeholder="Quantidade" naria-label="quantity" />
                        </FormGroup>
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

export default NewMovement;
