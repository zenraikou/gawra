import React, { Component } from "react";
import { Provider } from "mobx-react";

import "./App.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <>
        <Provider>
          <h1>gawra</h1>
        </Provider>
      </>
    );
  }
}
