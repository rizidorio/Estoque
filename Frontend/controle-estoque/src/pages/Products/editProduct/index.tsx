import React, { ChangeEvent, FormEvent, useEffect, useState } from 'react';
import { Alert, Button, Container, Form, FormControl, Row } from 'react-bootstrap';
import { Link, useHistory } from 'react-router-dom';
import api from '../../../services/api';

import './styles.css';

interface Product {
    sku: string,
    name: string,
    description: string,
    category: string,
    cust: number,    
}

interface ErroMsg {
    msg: string,
}

const EditProduct = ({}) => {
    const history = useHistory();
    const [erroMsg, setErroMsg] = useState<ErroMsg>();
    const [formData, setFormData] = useState({
        sku: '',
        name: '',
        description: '',
        category: '',
        cust: 0,    
    });
    
    const [product, setProduct] = useState<Product>({
        sku: '',
        name: '',
        description: '',
        category: '',
        cust: 0,    
    });
    
    const token = sessionStorage.getItem('login');
    const productSku = localStorage.getItem('productSku');
    
    useEffect(() => {
        api.get(`product/${productSku}`, {
             headers: {
                  "Authorization" : `bearer ${token}`
                 }, 
             }).then(response => {
             setProduct(response.data);
             setFormData(response.data);
         }).catch((error) => {
             console.log(error.response)
         })
     }, []);

    function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
        const {name, value} = event.target;
        setFormData({...formData, [name]: value});
    }
    
    async function handleSubmit(event: FormEvent) {
        event.preventDefault();

        const {sku, name, description, category, cust} = formData;

        const data = {
            sku: sku.toUpperCase(),
            name: name,
            description: description,
            category: category,
            cust: cust,    
        }
        api.post('product', data, {
            headers: {
                    "Authorization" : `bearer ${token}` 
            }
        }).then((response) => {
            setProduct(response.data);
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
                <Row>
                    <Form onSubmit={handleSubmit}>
                        <h4 className="mb-5">Nova unidade de medida</h4>
                        <FormControl onChange={handleInputChange} disabled className="mb-2" id="sku" name="sku" type="text" placeholder={product.sku ?? "SKU (entre 8 e 12 caracteres)"} naria-label="sku" />
                        <FormControl onChange={handleInputChange} className="mb-2" id="name" name="name" type="text" placeholder={product.name ??"Nome"} naria-label="name" />
                        <FormControl onChange={handleInputChange} className="mb-2" id="description" name="description" type="text" placeholder={product.description ?? "Descrição"} naria-label="description" />
                        <FormControl onChange={handleInputChange} className="mb-2" id="category" name="category" type="text" placeholder={product.category ?? "Categoria"} naria-label="category" />
                        <FormControl onChange={handleInputChange} className="mb-2" id="cust" name="cust" type="number" placeholder={product.cust.toString() ?? "Preço de custo"} naria-label="cust" />
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

export default EditProduct;
