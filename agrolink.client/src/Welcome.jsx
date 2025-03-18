import { Component } from 'react';

export default class Welcome extends Component {

    constructor(props) {
        super(props);

        this.state = { counter: 0 };
    }

    onSubmit(e) {
        e.preventDefault();
         let formData = e.data;
         let data = {
             name: formData.get("name"),
             location: formData.get("location"),
             phone: formData.get("phone"),
             email: formData.get("email"),
             datetime: new Date
         }

        let xhr = new XMLHttpRequest();
        xhr.open("post", "/registration/request", true);
        xhr.setRequestHeader("Content-Type", "application/json");
        xhr.onload = function () {
            if (xhr.status == 200) {

            }
        }
    }

    render() {
        return (
            <>
                <form action={this.onSubmit}>
                    <input name="name" placeholder="name"></input>
                    <input name="location" placeholder="location"></input>
                    <input name="phone" placeholder="phone"></input>
                    <input name="email" placeholder="email"></input>
                    <input type="submit" placeholder="Submit"></input>
                </form>
            </>
        );
    }   
}