import { createSelector } from "@reduxjs/toolkit";
import { RootState } from "../../store";

const selectState = (rs: RootState) => rs.user;
const selectUsers = createSelector([selectState], (state) => state.users);

const userSelectors = {
  selectState,
  selectUsers,
};

export default userSelectors;
