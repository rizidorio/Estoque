import React from 'react';
import { Button, Card } from 'react-bootstrap';
import { Link } from 'react-router-dom';

import './styles.css';

interface CardsProps {
    Header: string;
    background: string;
    idx: string;
    linkName1: string;
    linkAction1: string;
    linkClass1: string;
    linkName2: string;
    linkAction2: string;

}

const Cards: React.FC<CardsProps> = (props) => {
    return(
            <Card className="cards"
                border={props.background.toLowerCase()}
                key={props.idx}
            >
                <Card.Header>{props.Header}</Card.Header>
                <Card.Body className="cardBody">
                    <Link to={props.linkAction1} className={props.linkClass1} >{props.linkName1}</Link>
                    <Link to={props.linkAction2} className={props.linkClass1}>{props.linkName2}</Link>
                </Card.Body>
            </Card>
        );
}

export default Cards;