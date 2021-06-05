import React from 'react';
import { Button, Card } from 'react-bootstrap';

import './styles.css';

interface CardsProps {
    Header: string;
    background: string;
    idx: string;
    buttonName1: string;
    buttonName2: string;
    buttonBg: string;
}

const Cards: React.FC<CardsProps> = (props) => {
    return(
            <Card className="cards"
                bg={props.background.toLowerCase()}
                key={props.idx}
                text={props.background.toLowerCase() === 'light' ? 'dark' : 'white'}
            >
                <Card.Header className="text-center">{props.Header}</Card.Header>
                <Card.Body className="cardBody">
                    <Button className="cardButton" variant={props.buttonBg.toLowerCase()}>{props.buttonName1}</Button>
                    <Button variant={props.buttonBg.toLowerCase()}>{props.buttonName2}</Button>
                </Card.Body>
            </Card>
        );
}

export default Cards;