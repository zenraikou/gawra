import React, { Component } from "react";

export default class LoginRegisterBox extends Component {
  handleLogin = () => {
    // TODO: Implement login here.
  };

  render() {
    return (
      <div className="login-form">
        <h1 id="gawra">Gawra</h1>
        <div className="credentials">{/*className="credentials"> */}
          <input id="username" placeholder="Username" />
          <input type="password" id="password" placeholder="Password" />
        </div>
        <button id="login" onClick={this.handleLogin}>Login</button>
      </div>
    );
  }
}
