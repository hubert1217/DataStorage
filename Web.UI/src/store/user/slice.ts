import { createSlice } from "@reduxjs/toolkit";
import { UserState } from "./models";
import { getAll } from "./thunkActions";



const initialState: UserState = {
    users:[]
};


const userSlice = createSlice({
    name:"User",
    initialState,
    reducers:{},
    extraReducers: (builder) =>{
        builder.addCase(getAll.pending, (state)=>{
            state.users = [];
        });
        builder.addCase(getAll.rejected, (state)=>{
            state.users = [];
        });
        builder.addCase(getAll.fulfilled, (state, action)=>{
            state.users = action.payload;
        });
    }
})

export default userSlice;