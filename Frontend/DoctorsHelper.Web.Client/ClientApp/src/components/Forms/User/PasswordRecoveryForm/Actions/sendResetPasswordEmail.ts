import {
    AuthClient,
    UserClient
} from "../../../../../apiClient/apiClient";
import {baseUrl} from "../../../../../apiClient/baseUrl";
import {IErrors} from "../../../../../common/Interfaces";
import {getErrorsFromApiException} from "../../../../../apiClient/getErrorsFromApiException";

export const sendResetPasswordEmail = async (email: string) =>  {
    try {
        let authClient = new AuthClient(baseUrl);
        let client = new UserClient(authClient, baseUrl);
        let result = await client.sendResetPasswordEmail(email, document.location.href);
        return undefined;
    } catch (error) {
        return getErrorsFromApiException(error);
    }
}
