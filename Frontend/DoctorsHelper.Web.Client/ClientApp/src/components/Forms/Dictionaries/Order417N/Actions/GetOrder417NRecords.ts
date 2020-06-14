import {Order417NResponse, Order417NClient} from "../../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../../common/Interfaces';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function GetOrder417NRecords(searchText: string | null | undefined) {
    let res: IResult<Order417NResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new Order417NClient(getAuthClient());
        res.result = await client.getRecords(searchText);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response)
        return res;
    }
}