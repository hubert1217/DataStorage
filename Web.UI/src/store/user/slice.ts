import { createSlice } from "@reduxjs/toolkit";
import { UserState } from "./models";
import { getAll } from "./thunkActions";

const initialState: UserState = {
  users: [],
  isUserListLoading: false,
};

const userSlice = createSlice({
  name: "User",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(getAll.pending, (state) => {
      state.users = [];
      state.isUserListLoading = true;
    });
    builder.addCase(getAll.rejected, (state) => {
      state.users = [];
      state.isUserListLoading = false;
    });
    builder.addCase(getAll.fulfilled, (state, action) => {
      state.users = action.payload;
      state.isUserListLoading = false;
    });
  },
});

export default userSlice;
