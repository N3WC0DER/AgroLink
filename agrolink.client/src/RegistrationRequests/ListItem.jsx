import { Component } from 'react';

export default class ListItem extends Component {

    constructor(props) {
        super(props);
    }

    // use link to

    render() {
        const { requestId, name, handleClick } = this.props;

        return (
            <>
                <div className="item">
                    <div className="key">
                        {requestId }
                    </div>
                    <div className="name">
                        {name}
                    </div>
                    <button onClick={handleClick.bind(requestId) }>Change</button>
                </div>
            </>
        );
    }
}