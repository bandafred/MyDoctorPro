import {Order302NResponse, Order302NClient} from "../../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../../common/Interfaces';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function getOrder302NRecords(searchText: string | null | undefined) {
    let res: IResult<Order302NResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new Order302NClient(getAuthClient());
        res.result = await client.getRecords(searchText);

        return res;
    } catch (error) {
        res.error = JSON.parse(error.response) as IErrors;
        return res;
    }
}