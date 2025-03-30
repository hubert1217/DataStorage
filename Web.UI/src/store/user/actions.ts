import userSlice from "./slice";
import * as userThunkActions from "./thunkActions";

const userActions = {
  ...userSlice.actions,
  ...userThunkActions,
};

export default userActions;
