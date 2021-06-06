import React, { useEffect, useState } from 'react';
import { Container, Table } from 'react-bootstrap';
import { FiEdit, FiTrash } from 'react-icons/fi';
import { Link, useHistory } from 'react-router-dom';
import NavBar from '../../../components/navBar';

import api from '../../../services/api';

import './styles.css';

interface User {
    name: string,
    code: string,
    role: string,
}

const UsersList = () => {
    const history = useHistory();

    const [users, setUsers] = useState<User[]>([]);

    const token = sessionStorage.getItem('login');

    useEffect(() => {
        api.get('user', {
            headers: {
                 "Authorization" : `bearer ${token}` 
            }
        }).then(response => {
            setUsers(response.data);
        }).catch((error) => {
            console.log(error)
        });        
    }, []);

    async function handleDeleteUser(userCode: string) {
        await api.delete(`user/${userCode}`, {
            headers: {
                 "Authorization" : `bearer ${token}` 
            }
        }).then(response => {
            console.log(response.data);
        }).catch(error => {
           console.log(error.data);
        });
    }

    async function handleClick() {
        history.goBack();
    }

    return(
        <Container>
            <NavBar />
            <h4>Usuários</h4>
            <Link to="/newUser" className="btn btn-outline-success mb-5">Novo usuário</Link>
            <Link to="" onClick={handleClick} className="btn btn-outline-danger ml-2 mb-5">Voltar</Link>
            <Table striped bordered hover>
                <thead>
                <tr>
                    <th>Código</th>
                    <th>Nome</th>
                    <th>Perfil</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                    {users.map(user => (
                        <tr>
                            <td>{user.code}</td>
                            <td>{user.name}</td>
                            <td>{user.role}</td>
                            <td>
                                <Link className="mr-2 btn btn-outline-primary" to="/editUser" onClick={() => localStorage.setItem('userCode', user.code)}><FiEdit /></Link>
                                <Link className="btn btn-outline-danger" to="/home" onClick={() => handleDeleteUser(user.code)}><FiTrash /></Link>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}

export default UsersList;