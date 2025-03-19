import { Component } from 'react';

export default class ListItem extends Component {

    constructor(props) {
        super(props);
    }

    render() {
        const { requestId, name, datetime, select } = this.props;

        return (
            <>
                <div className="item" onClick={select}>
                    <div className="id">
                        {requestId }
                    </div>
                    <div className="name">
                        {name}
                    </div>
                    <div className="datetime">
                        {new Date(datetime + "Z").toLocaleString("ru")}
                    </div>
                </div>
            </>
        );
    }
}