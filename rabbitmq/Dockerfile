FROM rabbitmq:3.8-management

RUN apt-get update && \
  apt-get install -y curl

RUN curl -L https://github.com/rabbitmq/rabbitmq-delayed-message-exchange/releases/download/3.8.17/rabbitmq_delayed_message_exchange-3.8.17.8f537ac.ez > rabbitmq_delayed_message_exchange-3.8.17.ez

RUN mv rabbitmq_delayed_message_exchange-3.8.17.ez plugins/

RUN rabbitmq-plugins enable rabbitmq_delayed_message_exchange