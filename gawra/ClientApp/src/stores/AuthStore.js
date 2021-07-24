import { observable } from "mobx";
import axios from "../customAxios";
import BaseStore from "./BaseStore";

class AuthStore extends BaseStore {
  constructor() {
    super("auth");
  }
}

export default new AuthStore();
