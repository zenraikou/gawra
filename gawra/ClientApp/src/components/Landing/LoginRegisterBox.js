import React, { Component } from "react";

export default class LoginRegisterBox extends Component {
  handleLogin = () => {
    // TODO: Implement login here.
  };

  render() {
    return (
      <div className="login-box-container vertical-center">
        <input id="username" placeholder="Username" className="full-width" />
        <input id="password" placeholder="Password" className="full-width" />
        <button onClick={this.handleLogin}>Login</button>
      </div>
    );
  }
}
