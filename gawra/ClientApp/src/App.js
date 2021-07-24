import React, { Component } from "react";
import { Provider } from "mobx-react";
import { Landing } from "./components/Landing/Landing";
import { Route } from "react-router-dom";
import { PostStore, AuthStore } from "./stores";

import "./App.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <>
        <Provider postStore={PostStore} authStore={AuthStore}>
          <Route exact path="/" component={Landing} />
        </Provider>
      </>
    );
  }
}
