import React, { useEffect, useState } from 'react';
import { Container, Navbar, Table } from 'react-bootstrap';
import { FiEdit, FiTrash } from 'react-icons/fi';
import { Link } from 'react-router-dom';
import NavBar from '../../../components/navBar';

import api from '../../../services/api';

import './styles.css';

interface Product {
    sku: string,
    name: string,
    description: string,
    categoryId: number,
    measureId: number,
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

    return(
        <Container>
            <NavBar />
            <h4>Produtos</h4>
            <Link to="/newProduct" className="btn btn-outline-success mb-5">Novo produto</Link>
            <Table striped bordered hover>
                <thead>
                <tr>
                    <th>SKU</th>
                    <th>Nome</th>
                    <th>Descrição</th>
                    <th>Categoria</th>
                    <th>UM</th>
                    <th>Custo</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                    {product.map(product => (
                        <tr>
                            <td>{product.sku}</td>
                            <td>{product.name}</td>
                            <td>{product.description}</td>
                            <td>{product.categoryId}</td>
                            <td>{product.measureId}</td>
                            <td>{product.cust}</td>
                            <td>
                                <Link className="mr-2 btn btn-outline-primary" to="/"><FiEdit /></Link>
                                <Link className="btn btn-outline-danger" to="/"><FiTrash /></Link>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}

export default ProductList;