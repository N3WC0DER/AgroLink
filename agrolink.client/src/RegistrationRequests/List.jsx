import { Component } from 'react';
import { API } from './../api.jsx';
import ListItem from './ListItem.jsx';
import './List.scss';
import Request from './Request.jsx'
export default class List extends Component {

    constructor(props) {
        super(props);

        this.state = { requests: [], loading: true, error: null, selected: null }
    }

    componentDidMount() {
        let xhr = new XMLHttpRequest();
        xhr.open("get", API.registration_request, true);
        xhr.setRequestHeader("Content-Type", "application/json");
        xhr.onload = function () {
            if (xhr.status >= 200 && xhr.status < 300) {
                let requests = JSON.parse(xhr.response);
                console.debug("Requests loaded: " + requests.length);
                console.debug(requests);
                this.setState({ requests: requests, loading: false });
            } else {
                this.setState({ error: `Ошибка: ${xhr.statusText}`, loading: false });
            }
        }.bind(this);

        xhr.onerror = () => {
            console.debug("server error");
            this.setState({ error: 'Ошибка при выполнении запроса', loading: false });
        };

        xhr.send();
    }

    select(id) {
        const { requests } = this.state;
        const selected = requests.filter((value) => value.id == id);

        let state = this.state;
        state.selected = selected.at(0);
        this.setState(this.state);
    }

    render() {
        const { requests, loading, error, selected } = this.state;
        if (loading) return <> loading... </>
        if (error) return <> server error: { error } </>

        const listRequests = requests.map(request => {
            return <ListItem key={request.id} requestId={request.id} name={request.name} datetime={request.dateTime} select={this.select.bind(this, request.id)} />
        })

        return (
            <>
                <div id="requests">
                    <div id="list">
                        {listRequests}
                    </div>
                    <div id="request">
                        <Request request={selected} />
                    </div>
                </div>
            </>
        );
    }
}