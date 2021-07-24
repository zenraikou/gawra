import { observable } from "mobx";
import axios from "../customAxios";
import BaseStore from "./BaseStore";

class PostStore extends BaseStore {
  constructor() {
    super("post");
  }
}

export default new PostStore();
