import {Action as ReduxAction} from 'redux'

export interface Action<TPayload = void> extends ReduxAction<string>{
    payload:TPayload
}