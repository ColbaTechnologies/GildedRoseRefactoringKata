import { useState } from "react"
import { initalItems } from "./item";
import { updateItems } from "./update-item";

export const useItems = () => {
    const initialState = {
        day: 0,
        items: initalItems
    };
    const [state, setState] = useState({
        history: [initialState],
        current: initialState,
    });

    return {
        history: state.history,
        current: state.current,
        updateItemsOnANewDay: () => {
            const newCurrent = {
                day: state.current.day + 1,
                items: updateItems(state.current.items)
            };
            setState({
                current: newCurrent,
                history: [ ...state.history, newCurrent]
            });
        }
    }
}