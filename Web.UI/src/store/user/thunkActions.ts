import { createAsyncThunk } from "@reduxjs/toolkit";
import UsersClient from "../../api/UsersClient";

export const getAll = createAsyncThunk("User/getAll", async (thunkApi) => {
  return await UsersClient.getAll();
});
