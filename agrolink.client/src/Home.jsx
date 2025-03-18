import { Component } from 'react';

export default class Home extends Component {

    constructor(props) {
        super(props);

        this.state = { counter: 0 };
        console.log("test");
    }

    handleClick(e) {
        console.log(this.state);
        this.setState({
            counter: this.state.counter + 1
        });
    }

    render() {
        return (
            <>
                {this.state.counter}
                <button onClick={this.handleClick.bind(this)}>Test</button>
            </>
        );
    }
}