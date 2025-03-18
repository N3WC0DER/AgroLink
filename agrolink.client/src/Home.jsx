import { Component } from 'react';
import List from './RegistrationRequests/List';

export default class Home extends Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <>
                <List />
            </>
        );
    }
}