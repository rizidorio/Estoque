import React, { useEffect, useState } from 'react';
import { Container, Table } from 'react-bootstrap';
import { FiEdit, FiTrash } from 'react-icons/fi';
import { Link } from 'react-router-dom';
import NavBar from '../../../components/navBar';

import api from '../../../services/api';

import './styles.css';

interface Product {
    id: number
    sku: string,
    name: string,
    description: string,
    category: string,
    cust: number,    
}

const ProductList = () => {
    const [product, setProduct] = useState<Product[]>([]);

    const token = sessionStorage.getItem('login');

    useEffect(() => {
        api.get('product', {
            headers: {
                 "Authorization" : `bearer ${token}` 
            }
        }).then(response => {
            setProduct(response.data);
        }).catch((error) => {
            console.log(error)
        });        
    });

    async function handleDeleteProduct(productSku: string) {
        await api.delete(`product/${productSku}`, {
            headers: {
                 "Authorization" : `bearer ${token}` 
            }
        }).then(response => {
            console.log(response.data);
        }).catch(error => {
           console.log(error.data);
        });
    }

    return(
        <Container>
            <NavBar />
            <h4>Produtos</h4>
            <Link to="/newProduct" className="btn btn-outline-success mb-5">Novo produto</Link>
            <Table striped bordered hover>
                <thead>
                <tr>
                    <th>Id</th>
                    <th>SKU</th>
                    <th>Nome</th>
                    <th>Descrição</th>
                    <th>Categoria</th>
                    <th>Custo</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                    {product.map(product => (
                        <tr>
                            <td>{product.id}</td>
                            <td>{product.sku}</td>
                            <td>{product.name}</td>
                            <td>{product.description}</td>
                            <td>{product.category}</td>
                            <td>R$ {product.cust}</td>
                            <td>
                                <Link className="mr-2 btn btn-outline-primary" to="/editProduct" onClick={() => localStorage.setItem('productSku', product.sku)}><FiEdit /></Link>
                                <Link className="btn btn-outline-danger" to="/home" onClick={() => handleDeleteProduct(product.sku)}><FiTrash /></Link>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}

export default ProductList;