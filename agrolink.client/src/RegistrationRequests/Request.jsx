import { Component } from 'react';
import { API } from '../api.jsx';

export default class ListItem extends Component {

    constructor(props) {
        super(props);

        this.state = {
            prevRequest: this.props.request,
            
            inputs: [
                {name: "name", type: "text", value: "", isLocked: true},
                {name: "location", type: "text", value: "", isLocked: true},
                {name: "phone", type: "phone", value: "", isLocked: true},
                {name: "email", type: "email", value: "", isLocked: true},
            ],
        }
    }

    handleToggleLock = (id) => {
        this.setState((prevState) => ({
            prevRequest: prevState.prevRequest,

            inputs: prevState.inputs.map((input, index) =>
                index === id ? { ...input, isLocked: !input.isLocked } : input
            )
        }));
    };

    handleInputChange = (id, event) => {
        this.setState((prevState) => ({
            prevRequest: prevState.prevRequest,

            inputs: prevState.inputs.map((input, index) =>
                index === id ? { ...input, value: event.target.value } : input
            )
        }));
    };

    onSubmit = (req) => {

        const { inputs } = this.state;

        const request = {
            id: req.id,
            name: inputs.find(input => input.name === "name").value,
            location: inputs.find(input => input.name === "location").value,
            phone: inputs.find(input => input.name === "phone").value,
            email: inputs.find(input => input.name === "email").value,
            datetime: req.dateTime,
            linkEndpoint: req.linkEndpoint
        };

        let xhr = new XMLHttpRequest();
        xhr.open("put", API.registration_request + "/" + request.id, true);
        xhr.setRequestHeader("Content-Type", "application/json");
        xhr.onload = function () {
            console.debug("done.");
            window.location.reload();
        }

        xhr.onerror = function () {
            console.debug("server error");
        }

        xhr.send(JSON.stringify(request));
    }


    render() {
        const { request } = this.props;
        const { prevRequest } = this.state;

        if (prevRequest != request) {
            this.setState({
                prevRequest: request,

                inputs: [
                    { name: "name", type: "text", value: request.name, isLocked: true },
                    { name: "location", type: "text", value: request.location, isLocked: true },
                    { name: "phone", type: "phone", value: request.phone, isLocked: true },
                    { name: "email", type: "email", value: request.email, isLocked: true },
                ],
            })
        }

        let requestHtml = "Select request";

        if (request) {
            const { inputs } = this.state;

            requestHtml = (
                <>
                    <form action={this.onSubmit.bind(this, request)} autoComplete="off">
                        {
                            inputs.map((value, id) => (
                                <label key={id}>
                                    {value.name}:
                                    <div className="row">
                                        <input
                                            name={value.name}
                                            type={value.type}
                                            id={value.name}
                                            value={value.value}
                                            disabled={value.isLocked}
                                            onChange={(e) => this.handleInputChange(id, e)}
                                        />
                                        <button
                                            type="button"
                                            onClick={() => this.handleToggleLock(id)}
                                        >
                                            {value.isLocked ? 'Edit' : 'Save'}
                                        </button>
                                    </div>
                                </label>
                            ))
                        }
                        <span id="datetime">{new Date(request.dateTime + "Z").toLocaleString("ru")}</span>
                        <button type="submit">
                            Submit
                        </button>
                    </form>
                </>
            );
        }

        return (
            <>
                {requestHtml}
            </>
        );
    }
}