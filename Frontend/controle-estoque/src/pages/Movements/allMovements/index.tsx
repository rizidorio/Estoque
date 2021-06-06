import React, { useEffect, useState } from 'react';
import { Container, Table } from 'react-bootstrap';
import { FiEdit } from 'react-icons/fi';
import { Link, useHistory } from 'react-router-dom';
import NavBar from '../../../components/navBar';

import api from '../../../services/api';

import './styles.css';

interface Movement {
    productId: number,
    typeMovement: string,
    quantity: number,
    dateMovement: Date,    
}

const MovementList = () => {
    const history = useHistory();
    const [movement, setMovement] = useState<Movement[]>([]);

    const token = sessionStorage.getItem('login');

    useEffect(() => {
        api.get('stockMovement', {
            headers: {
                 "Authorization" : `bearer ${token}` 
            }
        }).then(response => {
            setMovement(response.data);
        }).catch((error) => {
            if(error.response){
                const statusCode: number = error.response.status;
                if(statusCode === 401){
                    sessionStorage.setItem('login', "");
                    history.push("/")
                }
            }
        });        
    });

    return(
        <Container>
            <NavBar />
            <h4>Lançamentos</h4>
            <Link to="/newMovement" className="btn btn-outline-success mb-5">Novo lançamento</Link>
            <Table striped bordered hover>
                <thead>
                <tr>
                    <th>ProdutoId</th>
                    <th>Tipo</th>
                    <th>Qdte</th>
                    <th>Data</th>
                </tr>
                </thead>
                <tbody>
                    {movement.map(movement => (
                        <tr>
                            <td>{movement.productId}</td>
                            <td>{movement.typeMovement}</td>
                            <td className={movement.typeMovement === "S" ? "text-danger" : "text-dark"}>{movement.quantity}</td>
                            <td>{new Date(movement.dateMovement).toLocaleDateString()}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}

export default MovementList;