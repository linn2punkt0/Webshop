import React, { Component } from "react";
import styled from "styled-components";
import Button from "./Button";

const StyledForm = styled.form`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  margin: 20px;

  input {
    margin: 5px;
  }
`;

class Form extends Component {
  constructor(props) {
    super(props);
    this.state = {
      cart_id: props.cart,
      name: "",
      adress: "",
      post: "",
      city: "",
      country: "",
      email: "",
      phone: ""
    };
  }

  handleInputChange = event => {
    const target = event.target;
    const value = target.type === "checkbox" ? target.checked : target.value;
    const name = target.name;
    this.setState({
      [name]: value
    });
  };

  handleSubmit = event => {
    event.preventDefault();
    const body = {
      customer: {
        customer_name: this.state.name,
        street_adress: this.state.adress,
        postal_code: this.state.post,
        city: this.state.city,
        country: this.state.country,
        email: this.state.email,
        phone_number: this.state.phone
      },
      cart_id: this.state.cart_id
    };
    console.log(body);

    fetch("https://localhost:5001/api/order", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(body)
    })
      // .then(response => {
      //   return response.json();
      // })
      // .then(myJson => {
      //   console.log(myJson);
      // })
      .catch(error => console.error(error));
  };
  render() {
    return (
      <StyledForm>
        <label htmlFor="name">Please enter your full name:</label>
        <input
          name="name"
          type="text"
          placeholder="first name and last name"
          onChange={this.handleInputChange}
          value={this.state.name}
        />
        <label htmlFor="adress">Please enter your street adress:</label>
        <input
          name="adress"
          type="text"
          placeholder="street adress"
          onChange={this.handleInputChange}
          value={this.state.adress}
        />
        <label htmlFor="post">Please enter your postal code:</label>
        <input
          name="post"
          type="text"
          placeholder="postal code"
          onChange={this.handleInputChange}
          value={this.state.post}
        />
        <label htmlFor="city">Please enter your city:</label>
        <input
          name="city"
          type="text"
          placeholder="city"
          onChange={this.handleInputChange}
          value={this.state.city}
        />
        <label htmlFor="country">Please enter your country:</label>
        <input
          name="country"
          type="text"
          placeholder="country"
          onChange={this.handleInputChange}
          value={this.state.country}
        />
        <label htmlFor="email">Please enter your email:</label>
        <input
          name="email"
          type="text"
          placeholder="email"
          onChange={this.handleInputChange}
          value={this.state.email}
        />
        <label htmlFor="phone">Please enter your phone number:</label>
        <input
          name="phone"
          type="text"
          placeholder="phone number"
          onChange={this.handleInputChange}
          value={this.state.phone}
        />
        <Button onClick={this.handleSubmit}>Submit</Button>
      </StyledForm>
    );
  }
}

export default Form;
