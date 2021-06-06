import React, { useEffect, useState } from 'react';
import { Container, Navbar, Table } from 'react-bootstrap';
import { FiEdit, FiTrash } from 'react-icons/fi';
import { Link } from 'react-router-dom';
import NavBar from '../../../components/navBar';

import api from '../../../services/api';

import './styles.css';

interface Categories {
    code: string,
    name: string,
}

const CategoriesList = () => {
    const [categories, setcategories] = useState<Categories[]>([]);

    const token = sessionStorage.getItem('login');

    useEffect(() => {
        api.get('category', {
            headers: {
                 "Authorization" : `bearer ${token}` 
            }
        }).then(response => {
            setcategories(response.data);
        }).catch((error) => {
            console.log(error)
        });        
    });

    return(
        <Container>
            <NavBar />
            <h4>Categorias</h4>
            <Link to="/newCategory" className="btn btn-outline-success mb-5">Nova categoria</Link>
            <Table striped bordered hover>
                <thead>
                <tr>
                    <th>Código</th>
                    <th>Nome</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                    {categories.map(category => (
                        <tr>
                            <td>{category.code}</td>
                            <td>{category.name}</td>
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

export default CategoriesList;