import React, { useEffect, useState } from 'react';
import { Container, Navbar, Table } from 'react-bootstrap';
import { FiEdit, FiTrash } from 'react-icons/fi';
import { Link } from 'react-router-dom';
import NavBar from '../../../components/navBar';

import api from '../../../services/api';

import './styles.css';

interface Measures {
    code: string,
    name: string,
    initials: string,
}

const MeasuresList = () => {
    const [measures, setMeasures] = useState<Measures[]>([]);

    const token = sessionStorage.getItem('login');

    useEffect(() => {
        api.get('measures', {
            headers: {
                 "Authorization" : `bearer ${token}` 
            }
        }).then(response => {
            setMeasures(response.data);
        }).catch((error) => {
            console.log(error)
        });        
    });

    return(
        <Container>
            <NavBar />
            <h4>Unidades de medida</h4>
            <Link to="/newMeasures" className="btn btn-outline-success mb-5">Nova unidade de medida</Link>
            <Table striped bordered hover>
                <thead>
                <tr>
                    <th>Código</th>
                    <th>Nome</th>
                    <th>Sigla</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                    {measures.map(measures => (
                        <tr>
                            <td>{measures.code}</td>
                            <td>{measures.name}</td>
                            <td>{measures.initials}</td>
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

export default MeasuresList;