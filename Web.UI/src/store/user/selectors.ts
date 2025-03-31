import { createSelector } from "@reduxjs/toolkit";
import { RootState } from "../../store";

const selectState = (rs: RootState) => rs.user;
const selectUsers = createSelector([selectState], (state) => state.users);
const selectIsUserListLoading = createSelector([selectState], (state)=>state.isUserListLoading);

const userSelectors = {
  selectState,
  selectUsers,
  selectIsUserListLoading,
};

export default userSelectors;
